import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./components/Login";
import SignUp from "./components/SignUp";
import UserTable from "./components/UserTable";
import PropertyTable from "./components/PropertyTable";
//import { AuthProvider } from "react-auth-kit";

function App() {
  return (
  /* <AuthProvider
      authType={"cookie"}
      authName={"_auth"}
      cookieDomain={window.location.hostname}
    >*/ 
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />}></Route>
        <Route path="/SignUp" element={<SignUp />}></Route>
        <Route path="/UserTable" element={<UserTable />}></Route>
        <Route path="/PropertyTable" element={<PropertyTable />}></Route>
      </Routes>
    </BrowserRouter>
   //</AuthProvider>
  );
}

export default App;
