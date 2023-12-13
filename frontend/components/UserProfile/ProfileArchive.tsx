import ArchiveCard from "./ArchiveCard";

const ProfileArchive = () => {
  const archives = ["Archive 1", "Archive 2", "Archive 3"];
  //  limit the posts visible to be only 3

  return (
    <div>
      <h2>Archived</h2>
      <div className="flex gap-2">
        {archives.map((archive, index) => (
          <ArchiveCard key={index} archive={archive} />
        ))}
      </div>
    </div>
  );
};

export default ProfileArchive;
