"use client";

import { usePathname } from "next/navigation";
import { useEffect, useState } from "react";

const Path = ({ title }: { title?: string }) => {
  const path = usePathname();

  const [formatedPath, setFormatedPath] = useState<string>("");

  useEffect(() => {
    const something = extractAuctionPath(path);
    const withUppercaseFirstLetterAfterSlash = something.replace(/\b\w/g, (l) =>
      l.toUpperCase()
    );
    const replaceDashWithSpace = withUppercaseFirstLetterAfterSlash.replace(
      /-/g,
      " "
    );
    setFormatedPath(replaceDashWithSpace);
  }, [path]);

  const extractAuctionPath = (path: string) => {
    const firstSlashIndex = path.indexOf("/");
    const secondSlashIndex = path.indexOf("/", firstSlashIndex + 1);

    if (secondSlashIndex !== -1) {
      return path.substring(1, secondSlashIndex);
    } else {
      // Handle the case where there is no second slash
      return path;
    }
  };

  return <div>{`${formatedPath}${title ? `/${title}` : " "}`}</div>;
};

export default Path;
