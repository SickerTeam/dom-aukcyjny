"use client";

import React, { useState, useEffect } from "react";

const CountdownTimer = ({ endsAt }: { endsAt: any }) => {
  const calculateTimeRemaining = () => {
    const now = new Date().getTime();
    const endTime = new Date(endsAt).getTime();
    const timeDifference = endTime - now;

    if (timeDifference > 0) {
      const days = Math.floor(timeDifference / (1000 * 60 * 60 * 24));
      const hours = Math.floor(
        (timeDifference % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)
      );
      const minutes = Math.floor(
        (timeDifference % (1000 * 60 * 60)) / (1000 * 60)
      );
      const seconds = Math.floor((timeDifference % (1000 * 60)) / 1000);

      return { days, hours, minutes, seconds };
    } else {
      return { days: 0, hours: 0, minutes: 0, seconds: 0 };
    }
  };

  const [timeRemaining, setTimeRemaining] = useState(calculateTimeRemaining);

  useEffect(() => {
    const timer = setInterval(() => {
      setTimeRemaining(calculateTimeRemaining);
    }, 1000);

    return () => {
      clearInterval(timer);
    };
  }, [endsAt]);

  const formatTime = (value: any) => (value < 10 ? `0${value}` : value);

  return (
    <div>
      Closes in {timeRemaining.days}d {formatTime(timeRemaining.hours)}h{" "}
      {formatTime(timeRemaining.minutes)}m {formatTime(timeRemaining.seconds)}s
    </div>
  );
};

export default CountdownTimer;
