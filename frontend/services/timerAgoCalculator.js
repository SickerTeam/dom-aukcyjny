const timeAgoCalculator = {
  
  calculateTimeAgo: (date) => {
    const postTime = typeof date === 'string' ? new Date(date) : date;
    postTime.setHours(postTime.getHours() + 1);
    const currentTime = new Date();
    const timeDifference = currentTime.getTime() - postTime.getTime();
   
    const minutesDifference = Math.floor(timeDifference / (1000 * 60));
    const hoursDifference = Math.floor(timeDifference / (1000 * 60 * 60));
    const daysDifference = Math.floor(timeDifference / (1000 * 60 * 60 * 24));
   
    return daysDifference > 0
       ? `${daysDifference} days ago`
       : hoursDifference > 0
       ? `${hoursDifference} hours ago`
       : `${minutesDifference} minutes ago`;
   },

   calculateTimeReamaning:  (date) => {
    const postTime = typeof date === 'string' ? new Date(date) : date;
    postTime.setHours(postTime.getHours() + 1);
    const currentTime = new Date();
    const timeDifference = currentTime.getTime() - postTime.getTime();
   
    if (Math.sign(timeDifference) < 0) {
        return "This auction ended";
     }
     
    const minutesDifference = Math.floor(timeDifference / (1000 * 60));
    const hoursDifference = Math.floor(timeDifference / (1000 * 60 * 60));
    const daysDifference = Math.floor(timeDifference / (1000 * 60 * 60 * 24));
   
    return daysDifference > 0
       ? `${daysDifference} days left`
       : hoursDifference > 0
       ? `${hoursDifference} hours left`
       : `${minutesDifference} minutes left`;
   },
   
};
 export default timeAgoCalculator;

