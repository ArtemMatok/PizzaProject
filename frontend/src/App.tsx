import { Outlet } from "react-router-dom";
import { Header } from "./components/shared/header";
import { ToastContainer } from "react-toastify";

const App = () => {
 
  return (
    <div>
      <ToastContainer position="top-center"/>
        <main className="min-h-screen">
          <Header />
          <Outlet /> 
        </main>
    </div>
  );
};

export default App;
