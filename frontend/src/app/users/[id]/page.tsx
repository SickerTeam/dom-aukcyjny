import { UsersPage } from "../../../../components";

type UserPageType = {
  params: {
    id: string;
  };
};

const UserPage = ({ params }: UserPageType) => {
  return <UsersPage id={params.id} />;
};

export default UserPage;
