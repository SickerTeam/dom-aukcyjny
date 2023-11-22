type AboutMeType = {
  description: string;
};

const AboutMe = ({ description }: AboutMeType) => {
  return (
    <div>
      <h2 className="pb-2">About me</h2>
      <p>{description}</p>
    </div>
  );
};

export default AboutMe;
