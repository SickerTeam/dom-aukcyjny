import React from 'react';

interface PictureCardProps {
    imageUrl: string;
}

const PictureCard: React.FC<PictureCardProps> = ({ imageUrl }) => {
    return (
        <div className='flex flex-column'>
             <img className="rounded-md h-auto max-w-full content-stretch" src={imageUrl} alt="Post Image" style={{objectFit: 'cover'}} />
        </div>

    );
};

export default PictureCard;