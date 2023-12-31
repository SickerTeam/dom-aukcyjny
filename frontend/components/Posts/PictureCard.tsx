import React from 'react';

interface PictureCardProps {
    imageUrl: string;
}

const PictureCard: React.FC<PictureCardProps> = ({ imageUrl }) => {
    return (
        <div>
            <img className="rounded-md" src={imageUrl} alt="Post Image" />
        </div>
    );
};

export default PictureCard;