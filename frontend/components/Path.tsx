"use client";

import { usePathname } from "next/navigation";

const Path = ({ title }: { title?: string }) => {
  const path = usePathname();

  const extractAuctionPath = (path: string) => {
    const firstSlashIndex = path.indexOf("/");
    const secondSlashIndex = path.indexOf("/", firstSlashIndex + 1);

    if (secondSlashIndex !== -1) {
      return path.substring(0, secondSlashIndex + 1);
    } else {
      // Handle the case where there is no second slash
      return path;
    }
  };

  return <div>{extractAuctionPath(path) + (title ? title : " ")}</div>; // add some styling
};

export default Path;
