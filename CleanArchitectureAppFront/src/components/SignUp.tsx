import { useState } from "react";
import "./Login.css";
import { Link, useNavigate } from "react-router-dom";
import axios from "axios";

function SignUp() {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [message, setMessage] = useState("");

  const navigate = useNavigate();

  const handleSubmit = async (e: { preventDefault: () => void }) => {
    e.preventDefault();
    try {
      const response = await axios.post(
        "https://localhost:32774/api/User/register",
        { name, email, password }
      );
      setMessage(`Registration Successfully`);
      navigate("/");
    } catch (error) {
      setMessage("Error");
    }
  };

  return (
    <div className="wrapper bg-dark d-flex align-items-center justify-content-center w-100">
      <div className="login rounded">
        <h2 className="mb-3">Sign Up</h2>
        <form className="needs-validation" onSubmit={handleSubmit}>
          <div className="form-group mb-2 was-validated">
            <label htmlFor="Name" className="form-label">
              Name:{" "}
            </label>
            <input
              type="name"
              placeholder="Name"
              className="form-control "
              value={name}
              onChange={(e) => setName(e.target.value)}
            ></input>
            <div className="invalid-feedback">Please Enter your email.</div>
          </div>
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
          <Link to="/">
            <span>Log in</span>
          </Link>
          <button type="submit" className="btn btn-success block mt-2 w-100">
            Submit
          </button>
        </form>
      </div>
    </div>
  );
}

export default SignUp;
