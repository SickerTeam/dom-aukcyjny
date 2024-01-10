import React, { useState } from "react";
import apiService from "../../services/apiService";

export default function PostAPost() {
 const [text, setText] = useState('');
 const [fileName, setFileName] = useState("");
 const [imagePreviewUrl, setImagePreviewUrl] = useState("");
 const [selectedFiles, setSelectedFiles] = useState<FileList | null>(null);
 let isRunning = false

 const userId = 1

 const handleSubmit = async (text: string) => {
  if (isRunning) {
    return
  }
  isRunning = true

   try {
     const createdAt = new Date().toISOString();
     let url;

     const response = await fetch("http://localhost:5156/Posts", {
       method: "POST",
       headers: {
         "Content-Type": "application/json",
       },
       body: JSON.stringify({ userId, text, createdAt }),
     });    

     if (response.ok) {
      const data = await response.json();
      const postId = data.id;
       const response2 = await fetch(`http://localhost:5156/Amazon?key=Posts/${postId}`);
       url = await response2.text();
     }

     if (url && selectedFiles) {
       const data = new FormData();
       data.append('file', selectedFiles[0], selectedFiles[0].name);
       const fileUpload = await fetch(url, {
         method: "PUT",
         headers: {
            "Content-Type": "image/jpeg",
          },
         body: selectedFiles[0],
       }).catch((error) => {
         console.error("Failed to upload picture:", error);
       });
     } else {
       console.log("Failed to create post");
     }
   } catch (error) {
     console.error("Error:", error);
   }
   setText("");
   setImagePreviewUrl("");
   setSelectedFiles(null)
   window.location.reload();
   isRunning = false
 };

 const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
   const { files } = event.target;
   setFileName(files?.[0]?.name || "");
   if (files?.[0]) {
     setImagePreviewUrl(URL.createObjectURL(files[0]));
     setSelectedFiles(files);
   }
 };

 return (
   <div className="border-2 border-grey-500/100 rounded-lg"> 
     <div>
       <textarea value={text} onChange={(e) => setText(e.target.value)} placeholder="Whats on your mind?" className="w-full focus:outline-none m-4"/>
     </div>
     
     {imagePreviewUrl && <img src={imagePreviewUrl} alt="Selected" />}
     <div className="flex justify-between">
     <input type="file" id="fileInput" style={{display: 'none'}} onChange={handleFileChange}/>
       <label htmlFor="fileInput" className="upload-icon">
         <img src="/../../like.ico" alt="Search Icon" className="w-6 h-6 m-4"  />
       </label>
       <button 
          onClick={() => handleSubmit(text)} 
          disabled={!text || !selectedFiles}
          className="flex items-center space-x-2 p-2 rounded-md bg-white hover:bg-gray-300"
        >
         <span className="m-2">Post</span>
       </button>
     </div> 
   </div>
 );
}
