"use client";

import { usePathname } from "next/navigation";

const Path = () => {
  const path = usePathname();

  return <div>{path}</div>; // add some styling
};

export default Path;
