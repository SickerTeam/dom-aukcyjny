import React from 'react';
import Image from 'next/image';

interface PictureCardProps {
    imageUrl: string;
}

const PictureCard: React.FC<PictureCardProps> = ({ imageUrl }) => {
    return (
        <div className=''>
             <Image className="rounded-md" src={imageUrl} alt="Post Image" width={500} height={500}  objectFit="cover" />
        </div>

    );
};

export default PictureCard;