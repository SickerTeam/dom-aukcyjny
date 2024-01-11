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
    <div>
      {history.map((bid, index) => (
        <div key={index}>{`${
          bid.user ? bid.user.firstName : "empty user"
        } | ${formatDate(bid.createdAt)} | € ${bid.amount}`}</div>
      ))}
    </div>
  );
};

export default BidHistory;
