"use client";
import { useState } from "react";

export default function CreatePostCard() {
    const [text, setText] = useState("");
    const [image, setImage] = useState<File | null>(null);
    const [userId, setUserId] = useState("1");

    function handlePost() {
        getImageUploadURL();

        fetch("http://localhost:5156/Posts", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                userId: userId,
                text: text,
                createdAt: new Date().toISOString() // Get current time in the specified format
            })
        })
            .then(response => response.json())
            .then(data => {
                console.log("API response:", data);
                // Handle the API response here
            })
            .catch(error => {
                console.error("API error:", error);
                // Handle the API error here
            });
    }

    function handleFileChange(e: React.ChangeEvent<HTMLInputElement>) {
        const file = e.target.files?.[0];
        setImage(file || null);
    }

    function getImageUploadURL() {
        fetch(`http://localhost:5156/Amazon?key=${encodeURIComponent(text)}`)
            .then(response => response.text())
            .then(data => {
                console.log("API response:", data);
                // Handle the API response here
                //uploadImageToS3(data);
            })
            .catch(error => {
                console.error("API error:", error);
                // Handle the API error here
            });
    }

    return (
        <>
            <input
                value={text}
                onChange={(e) => setText(e.target.value)}
                placeholder="What's on your mind?"
            />
            <input type="file" onChange={handleFileChange} />
            {image && <img src={URL.createObjectURL(image)} alt="Uploaded Image" />}
            <button onClick={handlePost}>Post</button>
        </>
    );
}
            