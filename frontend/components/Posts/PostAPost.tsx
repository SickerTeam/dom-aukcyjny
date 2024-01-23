import React, { useEffect, useState } from "react";
import apiService from "../../services/apiService";


export default function PostAPost() {
 const { v4: uuidv4 } = require('uuid');
 const [text, setText] = useState('');
 const [fileName, setFileName] = useState("");
 const [Link, setLink] = useState("");
 const [userId, setUserId] = useState("");
 const [selectedFiles, setSelectedFiles] = useState<FileList | null>(null);
 let isRunning = false

useEffect(() => {
  
 let token = sessionStorage.getItem('token'); 
 if (token) {
     let base64Url = token.split('.')[1];
     let base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
     let jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
         return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
     }).join(''));
 
     let payload = JSON.parse(jsonPayload);
     let nameid = payload.nameid;
     setUserId(nameid);
 }
}, []);




 const handleSubmit = async (text: string) => {
  if (isRunning) {
    return
  }
  isRunning = true
  const name = uuidv4();

   try {
    const accessUrl = (`https://zongbucket.s3.eu-north-1.amazonaws.com/Posts/${name}`)
     const uploadResponse = await fetch(`https://localhost:5156/Amazon?key=Posts/${name}`);
     let fileUpload;
     const uploadurl = await uploadResponse.text();

     if (uploadResponse.ok && selectedFiles) {
       const data = new FormData();
       data.append('file', selectedFiles[0], selectedFiles[0].name);
       fileUpload = await fetch(uploadurl, {
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

     if (fileUpload) {
     const response2 = await fetch("https://localhost:5156/Posts", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ userId, text, imageLink: accessUrl}),
      });
     }
   } catch (error) {
     console.error("Error:", error);
   }
   setText("");
   setLink("");
   setSelectedFiles(null)
   window.location.reload();
   isRunning = false
 };

 const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
   const { files } = event.target;
   setFileName(files?.[0]?.name || "");
   if (files?.[0]) {
     setLink(URL.createObjectURL(files[0]));
     setSelectedFiles(files);
   }
 };

 return (
   <div className="border-2 border-grey-500/100 rounded-lg"> 
     <div>
       <textarea value={text} onChange={(e) => setText(e.target.value)} placeholder="Whats on your mind?" className="w-full focus:outline-none m-4"/>
     </div>
     
     {Link && <img src={Link} alt="Selected" />}
     <div className="flex justify-between">
     <input type="file" id="fileInput" style={{display: 'none'}} onChange={handleFileChange}/>
       <label htmlFor="fileInput" className="upload-icon">
         <img src="/../../image.svg" alt="Search Icon" className="w-6 h-6 m-4"  />
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
