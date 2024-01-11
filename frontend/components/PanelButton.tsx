"use client";

import { PanelButtonProps } from "../types";

const PanelButton = ({ text, onClick }: PanelButtonProps) => {
  return (
    <button
      type="button"
      className="px-4 py-1 border-dark-gray border-2 rounded bg-white"
      onClick={onClick}
    >
      {text}
    </button>
  );
};

export default PanelButton;
