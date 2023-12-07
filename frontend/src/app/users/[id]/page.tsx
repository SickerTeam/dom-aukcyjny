import { UserPage } from "../../../../components";

type UserType = {
  params: {
    id: string;
  };
};

const User = ({ params }: UserType) => {
  return <UserPage userId={params.id} />;
};

export default User;
