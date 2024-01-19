"use client";

import React, { useState, useRef, useEffect } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faChevronLeft,
  faChevronRight,
} from "@fortawesome/free-solid-svg-icons";
import ArtistCard from "./ArtistCard";
import apiService from "../services/apiService";

const ArtistsOverview =  () => {
  const [artists, setArtists] = useState([]);
  const [artistNubmer, setArtistNumber] = useState(0);
  const [artNubmer, setArtNumber] = useState(0);

  useEffect(() => {
    // fetch(`https://localhost:5156/Users`)
    //   .then((res) => {
    //     res.json().then((data) => {
    //       setArtists(data);
    //     });
    //   }).catch((error) => console.error(error));
    const fetchArtists = async () => {
      try {
        const response = await apiService.get(`/Users`);
        setArtists(response);
      } catch (error) {
        console.error(error);
      }
    }
    fetchArtists();
  }, []);

  const scrollContainer = useRef<HTMLDivElement>(null);
  const [showArrows, setShowArrows] = useState({ left: false, right: false });

  const handleScroll = (direction: "left" | "right") => {
    const container = scrollContainer.current;

    if (container) {
      const scrollAmount = 400;
      const newPosition =
        direction === "right"
          ? container.scrollLeft + scrollAmount
          : container.scrollLeft - scrollAmount;

      container.scrollTo({
        left: newPosition,
        behavior: "smooth",
      });
    }
  };

  const handleScrollVisibility = () => {
    const container = scrollContainer.current;

    if (container) {
      const scrollLeft = container.scrollLeft;
      const maxScrollLeft = container.scrollWidth - container.clientWidth;

      setShowArrows({
        left: scrollLeft > 0,
        right: scrollLeft < maxScrollLeft,
      });
    }
  };

  useEffect(() => {
    const container = scrollContainer.current;

    if (container) {
      handleScrollVisibility();
      container.addEventListener("scroll", handleScrollVisibility);
      return () => {
        container.removeEventListener("scroll", handleScrollVisibility);
      };
    }
  }, []);

  return (
    <div style={{ position: "relative" }}>  
      <h2 className="text-xl  ">
        Buy or bid on over{" "}
        <span className="italic text-main-green">372 objects</span> every
        week, created by{" "}
        <span className="italic text-main-green">{artists.length} artists</span>
      </h2>
      <div className="flex justify-center">
        <div className="scroll-arrows">
          {showArrows.left ? (
            <button className="left" onClick={() => handleScroll("left")}>
              <FontAwesomeIcon icon={faChevronLeft} />
            </button>
          ) : (
            <div></div>
          )}
          {showArrows.right && (
            <button className="right" onClick={() => handleScroll("right")}>
              <FontAwesomeIcon icon={faChevronRight} />
            </button>
          )}
        </div>
      </div>
      <div className="artists-scroll-container" ref={scrollContainer}>
        <div className="flex gap-6 flex-nowrap my-2  ">
          {artists.map((artist, index) => (
            <ArtistCard key={index} artist={artist} />
          ))}
        </div>
      </div>
    </div>
  );
};

export default ArtistsOverview;
