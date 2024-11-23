import React from 'react';
import Header from './components/Header';
import Footer from './components/Footer';
import About from './components/About'; // Importando a página Sobre Nós
import Contact from './components/Contact'; // Importando a página Fale Conosco
import Products from './components/Products'; // Importando a página Fale Conosco
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'; // Importando as rotas

import { UserProvider } from './utils/UserContext';
import { CartProvider } from './utils/CartContext'; 
import './App.css';

const App = () => (
  <CartProvider>
    <UserProvider>
      <Router>
        <div className="App">
          <Header />
          <div className="content">
            <Routes>
              <Route path="/" element={<Products />} />
              <Route path="/about" element={<About />} />
              <Route path="/contact" element={<Contact />} />
            </Routes>
          </div>
          <Footer />
        </div>
      </Router>
    </UserProvider>
  </CartProvider>
);

export default App;
