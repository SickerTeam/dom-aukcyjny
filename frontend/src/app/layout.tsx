import "./globals.css";
import { Footer, Navbar } from "../../components";
import { Analytics } from '@vercel/analytics/react';

export const metadata = {
  title: "Dom Aukcyjny",
  description: "Welcome to Zong",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className="px-60">
        <Navbar />
        {children}
        <Analytics />
        <Footer />
      </body>
    </html>
  );
}
