import React from "react";

export const Footer = () => {
  return (
    <footer className="bg-main-green text-white mt-14 rounded-t-3xl flex justify-between pt-8 px-40">
      <div className="w-1/5 flex flex-col">
        <h4 className="text-2xl">About Zongers</h4>
        <a href="/about" className="text-lg">
          About Zongers
        </a>
      </div>
      <div className="w-1/5 flex flex-col">
        <h4 className="text-2xl">Buy</h4>
        <a href="/how-to-buy" className="text-lg">
          How to Buy
        </a>
        <a href="/buyer-protection" className="text-lg">
          Buyer Protection
        </a>
        <a href="/buyer-terms" className="text-lg">
          Buyer terms
        </a>
      </div>
      <div className="w-1/5 flex flex-col">
        <h4 className="text-2xl">Sell</h4>
        <a href="/how-to-sell" className="text-lg">
          How to Sell
        </a>
        <a href="/submission-guidelines" className="text-lg">
          Submission guidelines
        </a>
        <a href="/seller-terms" className="text-lg">
          Seller terms
        </a>
      </div>
      <div className="w-1/5 flex flex-col">
        <h4 className="text-2xl">My Zongers</h4>
        <a href="/sign-in" className="text-lg">
          Sign in
        </a>
        <a href="/register" className="text-lg">
          Register
        </a>
        <a href="/help" className="text-lg">
          Help
        </a>
      </div>
    </footer>
  );
};

export default Footer;
