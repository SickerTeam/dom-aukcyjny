import Image from "next/image";

type ArtistCardType = {
  artist: any;
};

const ArtistCard = ({ artist }: ArtistCardType) => {
  return (
    <div>
      
      <div className="w-[300px] h-[300px] bg-light-gray rounded relative"> 
        <Image  
          src={artist.imageLink} 
          alt="Post Image"
          layout="fill"
          objectFit="cover"
          quality={100}
          /> 
      </div>
      <h3 className="font-semibold">{artist.firstName} {artist.lastName}</h3>
      <p>{artist.bio}</p>
    </div>
  );
};

export default ArtistCard;
