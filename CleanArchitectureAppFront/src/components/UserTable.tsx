import axios from "./authInstance";

function UserTable() {
  const users = [
    { userName: "Pato", name: "Patricio", email: "pm@gmail.com" },
    { userName: "Mig", name: "Migli", email: "ms@gmail.com" },
  ];

  return (
    <div>
      <h1>Users</h1>
      <table className="table table-sm table-striped table-bordered">
        <tbody>
          <tr>
            <td>UserName</td>
            <td>Name</td>
            <td>Email</td>
          </tr>
          {users.map((item, i) => (
            <tr key={i}>
              <td>{item.userName}</td>
              <td>{item.name}</td>
              <td>{item.email}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default UserTable;
