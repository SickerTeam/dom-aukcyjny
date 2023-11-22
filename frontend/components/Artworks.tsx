import ArtworkCard from './ArtworkCard'

interface IArtworks {
  artworks: any[]
}

const Artworks = ({artworks}: IArtworks) => {
    
  return (
    <div className="grid grid-cols-5 gap-4 m-10">
      {artworks.map((artwork, index) => (
        <div key={index}>
          <ArtworkCard artwork={artwork}/>
        </div>
      ))}
    </div>
  )
}

export default Artworks