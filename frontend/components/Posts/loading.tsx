'use client'

import { useState } from "react"

export default function Loadinf() {
    const[loading, setLoading] = useState(true)
    return (
        <div>
           <h1>loading...</h1>
        </div>
        )
}