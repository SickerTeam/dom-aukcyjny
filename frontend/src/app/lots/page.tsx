"use client";

import { useState } from "react";

const CreatingListingsPage = () => {
  const [step, setStep] = useState(0);

  const renderStepContent = () => {
    switch (step) {
      case 0:
        // return <FirstStep />;
        return (
          <div className="pb-12">
            <h1 className="text-4xl">
              Find the perfect buyer for your{" "}
              <span className="text-main-green italic">unique painting</span>
            </h1>

            <input
              accept="image/png,image/gif,image/jpeg"
              multiple
              type="file"
              autoComplete="off"
              //   className="w-1/3 h-[400px] bg-gray-200"
              className="none"
              placeholder="Upload your image"
            />
          </div>
        );
      case 1:
        // return <SecondStep />;
        return (
          <div className="h-[200px] bg-red-300">
            <h1>Second Step</h1>
          </div>
        );
      case 2:
        // return <ThirdStep />;
        return (
          <div className="h-[200px] bg-red-300">
            <h1>Third Step</h1>
          </div>
        );
    }
  };

  return (
    <div className="w-full">
      <div className="w-full h-12 border-light-gray border-y-[1px] flex justify-around mb-8">
        <button onClick={() => setStep(0)}>First</button>
        <button onClick={() => setStep(1)}>Second</button>
        <button onClick={() => setStep(2)}>Third</button>
      </div>
      {renderStepContent()}
    </div>
  );
};

export default CreatingListingsPage;
