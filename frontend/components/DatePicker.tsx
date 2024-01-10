import { useState } from "react";

const TwoWeeksFromNow = new Date();
TwoWeeksFromNow.setDate(TwoWeeksFromNow.getDate() + 14);
TwoWeeksFromNow.setUTCHours(20, 0, 0, 0);

type DatePickerType = {
  onChange: (date: Date) => void;
};

const DatePicker = ({ onChange }: DatePickerType) => {
  const [selectedDate, setSelectedDate] = useState(
    TwoWeeksFromNow.toISOString().slice(0, 16)
  );

  const handleChange = (e: any) => {
    const date = new Date(e.target.value);
    setSelectedDate(e.target.value);
    onChange(date);
  };

  return (
    <div className="flex flex-col w-1/3 h-14 mb-4">
      <label htmlFor="auctionDate" className="text-black text-md uppercase">
        Auction End Date
      </label>
      <input
        type="datetime-local"
        id="auctionDate"
        name="auctionDate"
        className="bg-red-300 h-full"
        value={selectedDate}
        onChange={handleChange}
      />
    </div>
  );
};

export default DatePicker;
