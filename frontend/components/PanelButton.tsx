"use client";

import { PanelButtonProps } from "../types";

const PanelButton = ({ text, onClick }: PanelButtonProps) => {
  return (
    <button
      type="button"
      className="px-4 py-1 shadow-sm rounded bg-white w-full"
      onClick={onClick}
    >
      {text}
    </button>
  );
};

export default PanelButton;
