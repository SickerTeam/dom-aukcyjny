type UserCardType = {
    user: any
}

const UserCard = async ({user} : UserCardType ) => {
    console.log(user)
    return (
        <div>
            <li className="flex items-center font-medium whitespace-nowrap px-5 mt-6">
                <img src={`https://zongbucket.s3.eu-north-1.amazonaws.com/users/${user.id}` || '/../../cv3.png'} alt="" className="mr-3 w-9 h-9 rounded-full bg-slate-50 dark:bg-slate-800" decoding="async" />
                <div className="text-sm leading-4">
                    <div className="text-slate-900 dark:text-slate-800">{user && user.firstName} {user && user.lastName} </div>
                    <div className="mt-1">
                        <a href="https://www.youtube.com/watch?v=6yTpJFgTB8s&ab_channel=Jasperium" className="text-sky-500 hover:text-sky-600 dark:text-sky-400">username</a>
                    </div>
                </div>
            </li>
        </div>
    );               
};

export default UserCard;
