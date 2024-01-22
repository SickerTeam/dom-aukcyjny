type BidHistoryType = {
  history: any[];
};

const BidHistory = ({ history }: BidHistoryType) => {
  if (!history) return <div>loading...</div>;

  const formatDate = (dateString: string) => {
    const date = new Date(dateString);
    const options: Intl.DateTimeFormatOptions = {
      month: "short",
      day: "numeric",
      hour: "numeric",
      minute: "numeric",
      second: "numeric",
      hour12: false,
    };

    return date.toLocaleString("en-US", options);
  };

  return (
    <div className="flex flex-col gap-2 w-full">
      {history.map((bid, index) => (
        <div key={index} className="flex justify-between">
          <p>{bid.user?.firstName}</p>
          <p>{formatDate(bid.createdAt)}</p>
          <p>€ {bid.amount}</p>
        </div>
      ))}
    </div>
  );
};

export default BidHistory;
