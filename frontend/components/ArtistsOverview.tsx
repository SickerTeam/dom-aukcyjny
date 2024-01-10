"use client";

import React, { useState, useRef, useEffect } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faChevronLeft,
  faChevronRight,
} from "@fortawesome/free-solid-svg-icons";
import ArtistCard from "./ArtistCard";

const ArtistsOverview = () => {
  const artists = [
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
  ];

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
        <span className="italic text-main-green">2,137 objects</span> every
        week, created by{" "}
        <span className="italic text-main-green">420+ artists</span>
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
