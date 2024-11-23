import React from 'react';
import Header from './components/Header';
import Footer from './components/Footer';
import About from './components/About';
import Contact from './components/Contact'; 
import Products from './components/Products'; 
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import { UserProvider } from './utils/UserContext';
import { CartProvider } from './utils/CartContext'; 
import './App.css';

const App = () => (
  <CartProvider>
    <UserProvider>
      <Router basename='/'>
        <div className="App">
          <Header />
          <div className="content">
            <Routes>
              <Route path="/" element={<Products />} />
              <Route path="/about" element={<About />} />
              <Route path="/contact" element={<Contact />} />
              <Route path="*" element={<h1>404 - Página não encontrada</h1>} />
            </Routes>
          </div>
          <Footer />
        </div>
      </Router>
    </UserProvider>
  </CartProvider>
);

export default App;
