import { Outlet } from "react-router-dom";
import { Header } from "./components/shared/header";

const App = () => {
 
  return (
    <div>
        <main className="min-h-screen">
          <Header />
          <Outlet />
        </main>
    </div>
  );
};

export default App;
