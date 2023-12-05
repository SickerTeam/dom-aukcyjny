import UserCard from "./UserCard";

const SideRecommendation = () => {
    return (
        <div>
            <div>
                <h1 className="text-2xl font-bold">Connect with others</h1>
            </div>
            <div>
            {[...Array(5)].map((_, index) => (
                <UserCard key={index} />
            ))}
            </div>
            <div>
                <a href="https://twitter.com/adamwathan" className="text-sky-500 hover:text-sky-600 dark:text-sky-400">Find more...</a>
            </div>
        </div>
    );   
};

export default SideRecommendation;