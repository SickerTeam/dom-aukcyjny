"use client";

import { useState } from "react";
import DatePicker from "../../../components/DatePicker";
import LotForm from "../../../components/LotForm";

const CreatingListingsPage = () => {
  const [step, setStep] = useState(0);
  const [formData, setFormData] = useState({
    title: "",
    artist: "",
    year: "",
    width: "",
    height: "",
    depth: "",
    weight: "",
    datePickerValue: "",
    description: "",
    estimateMin: "",
    estimateMax: "",
  });

  const handleDatePickerChange = (date: Date) => {
    setFormData({
      ...formData,
      datePickerValue: date.toISOString(),
    });
  };

  const renderStepContent = () => {
    switch (step) {
      case 0:
        // return <FirstStep />;
        return <LotForm />;
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
        <button
          onClick={() => {
            setStep(0);
            console.log(formData);
          }}
        >
          First
        </button>
        <button onClick={() => setStep(1)}>Second</button>
        <button onClick={() => setStep(2)}>Third</button>
      </div>
      {renderStepContent()}
    </div>
  );
};

export default CreatingListingsPage;
