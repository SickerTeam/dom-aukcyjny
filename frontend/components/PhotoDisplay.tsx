"use client";

import React, { useRef, useState } from "react";

type PhotoDisplayType = {
  photos: string[];
};

const PhotoDisplay = ({ photos }: PhotoDisplayType) => {
  const maxVisiblePhotos = 3;
  const [showAll, setShowAll] = useState(false);
  const lastVisibleIndex = maxVisiblePhotos - 1;
  const buttonRef = useRef<HTMLButtonElement>(null);

  const scrollToButton = () => {
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
          } bg-main-green h-[500px] relative p-4 rounded-lg shadow-sm`}
        >
          <img alt="" src={photo} className="object-cover w-full h-full" />
          {index === lastVisibleIndex && photos.length > maxVisiblePhotos && (
            <button
              ref={buttonRef}
              className="absolute right-0 bottom-0 p-2 bg-light-gray"
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
