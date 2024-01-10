import Link from "next/link";
import React from "react";

export const Footer = () => {
  return (
    <footer className="bg-main-green text-light-gray mt-14 full-bleed">
      <div className="flex justify-between py-16">
        <div className="w-1/5 flex flex-col">
          <h4 className="text-xl text-white">About Zongers</h4>
          <Link href="/about">About Zongers</Link>
        </div>
        <div className="w-1/5 flex flex-col">
          <h4 className="text-xl text-white">Buy</h4>
          <Link href="/how-to-buy">How to Buy</Link>
          <Link href="/buyer-protection">Buyer Protection</Link>
          <Link href="/buyer-terms">Buyer terms</Link>
        </div>
        <div className="w-1/5 flex flex-col">
          <h4 className="text-xl text-white">Sell</h4>
          <Link href="/how-to-sell">How to Sell</Link>
          <Link href="/submission-guidelines">Submission guidelines</Link>
          <Link href="/seller-terms">Seller terms</Link>
        </div>
        <div className="w-1/5 flex flex-col">
          <h4 className="text-xl text-white">My Zongers</h4>
          <Link href="/sign-in">Sign in</Link>
          <Link href="/register">Register</Link>
          <Link href="/help">Help</Link>
        </div>
      </div>
      <div className="w-full h-[1px] bg-white"></div>
      <div className="mt-2 h-24 flex justify-between items-center">
        <Link href="/help/terms-of-use">Terms of use</Link>
        <Link href="/help/buyer-terms/privacy-policy">
          Data Protection & Privacy Notice
        </Link>
        <Link href="/help/cookies">Cookie Policy</Link>
        <Link href="/help/law-enforcement-policy">Law Enforments Policy</Link>
        <Link href="/help/buyer-terms/other-policies">Other Policies</Link>
        <p>© 2023</p>
      </div>
    </footer>
  );
};

export default Footer;
