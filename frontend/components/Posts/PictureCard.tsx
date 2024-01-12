import React from 'react';
import Image from 'next/image';

interface PictureCardProps {
    image: string;
}

const PictureCard: React.FC<PictureCardProps> = ({ image }) => {
    return (
        <div className=''>
             <Image className="rounded-md" src={image} alt="Post Image" width={500} height={500}  objectFit="cover" />
        </div>

    );
};

export default PictureCard;