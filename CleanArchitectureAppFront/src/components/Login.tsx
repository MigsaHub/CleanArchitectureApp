import { useState } from "react";
import "./Login.css";
import { Link, useNavigate } from "react-router-dom";
  
import axios from "./authInstance";
//import { AuthProvider } from "react-auth-kit";

function Login() {
  const [name] = useState("Pato");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [message, setMessage] = useState("");
//const signIn = useSignIn();

  const navigate = useNavigate();

  /*const handleSubmit = async (e: { preventDefault: () => void }) => {
    e.preventDefault();
    try {
      const response = await axios
        .post("https://localhost:32774/api/User/Login", {
          name,
          email,
          password,
        })
        .then((res) => console.log(res))
        .catch((err) => console.log(err));

      setMessage("Login Succesfull");
      navigate("PropertyTable");
    } catch (error) {}
    setMessage("Error logging in");
  };*/

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post("https://localhost:32774/api/User/Login", {
        name,
        email,
        password,
      });
      localStorage.setItem('token', response.data);
      setMessage('User logged in');
      navigate("PropertyTable");
    } catch (error) {
      setMessage('Error logging in');
    }
  };


  return (
    <div className="wrapper bg-dark d-flex align-items-center justify-content-center w-100">
      <div className="login rounded">
        <h2 className="mb-3">Please Login</h2>
        <form className="needs-validation" onSubmit={handleSubmit}>
          <div className="form-group mb-2 was-validated">
            <label htmlFor="email" className="form-label">
              Email:{" "}
            </label>
            <input
              type="email"
              placeholder="Email"
              className="form-control "
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            ></input>
            <div className="invalid-feedback">Please Enter your email.</div>
          </div>
          <div className="form-group mb-2 was-validated ">
            <label htmlFor="password" className="form-label">
              Password:{" "}
            </label>
            <input
              type="password"
              placeholder="Password"
              className="form-control"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            ></input>
            <div className="invalid-feedback">Please Enter your password.</div>
          </div>
          <Link to="/SignUp">
            <span>Sign Up</span>
          </Link>
          <button type="submit" className="btn btn-success block mt-2 w-100">
            Log in
          </button>
        </form>
      </div>
    </div>
  );
}

export default Login;
