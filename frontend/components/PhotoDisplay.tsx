"use client";

import React, { useRef, useState } from "react";

type PhotoDisplayType = {
  photos: number[];
};

const PhotoDisplay = ({ photos }: PhotoDisplayType) => {
  const maxVisiblePhotos = 3;
  const [showAll, setShowAll] = useState(false);
  const lastVisibleIndex = maxVisiblePhotos - 1;
  const buttonRef = useRef<HTMLButtonElement>(null);

  const scrollToButton = () => {
    // cant figure out a way to fix how it scrolls to the random point, and not to the 10px from the top (look catawiki - same functionality)
    if (buttonRef.current) {
      const rect = buttonRef.current.getBoundingClientRect();
      const containerHeight = 500;
      window.scrollTo({
        top: window.scrollY + rect.top + containerHeight + 10,
        behavior: "smooth",
      });
    }
  };

  const visiblePhotos = showAll ? photos : photos.slice(0, maxVisiblePhotos);

  return (
    <div className="relative grid grid-cols-2 gap-4">
      {visiblePhotos.map((photo, index) => (
        <div
          key={index}
          className={`col-span-${
            index % 3 === 0 ? "2" : "1"
          } bg-blue-400 h-[500px] relative`}
        >
          {photo}
          {index === lastVisibleIndex && photos.length > maxVisiblePhotos && (
            <button
              ref={buttonRef}
              className="absolute right-0 bottom-0 p-2 bg-red-400 text-white"
              onClick={() => {
                setShowAll(!showAll);
                !showAll && scrollToButton();
              }}
            >
              {showAll
                ? "See fewer photos"
                : `Show all photos (${photos.length})`}
            </button>
          )}
        </div>
      ))}
    </div>
  );
};

export default PhotoDisplay;
