import { UsersPage } from "../../../../components";

type UserPageType = {
  params: {
    id: string;
  };
};

const UserPage = ({ params }: UserPageType) => {
  return <UsersPage userId={params.id} />;
};

export default UserPage;
