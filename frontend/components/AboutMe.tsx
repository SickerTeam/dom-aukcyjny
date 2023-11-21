type AboutMeType = {
  description: string;
};

const AboutMe = ({ description }: AboutMeType) => {
  return <p>{description}</p>;
};

export default AboutMe;
