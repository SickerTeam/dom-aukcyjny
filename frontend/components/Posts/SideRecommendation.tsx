import UserCard from "./UserCard";

type UserCardType = {
    user: any[];
}

const SideRecommendation = async ({ user }: UserCardType) => {
    return (
        <div>
            <div>
                <h1 className="text-2xl font-bold">Connect with others</h1>
            </div>
            {user.map((user: any, index: number) => <UserCard key={index} user={user} />)}
            <UserCard user={user} />
        </div>
    );
}
           
export default SideRecommendation;
