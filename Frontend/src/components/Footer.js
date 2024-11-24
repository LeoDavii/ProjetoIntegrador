import React from 'react';
import { FaGithub, FaVideo, FaLinkedin } from 'react-icons/fa';
import './styles/Footer.css';

const Footer = () => (
    <footer className="footer">
        <div className="footer-section">
            <h4>Tiny Little Cakes</h4>
            <a href="about">Sobre Nós</a>
            <a href="contact">Fale Conosco</a>
        </div>
        <div className="footer-section">
            <h4>Social</h4>
            <div className="social-icons">
            <a
                href="https://www.linkedin.com/in/leonardo-davi-tavares"
                target="_blank"
                rel="noopener noreferrer"
                style={{ textDecoration: 'none', color: 'inherit' }}
                >
                <FaLinkedin />
            </a>  
            <a
            href="https://github.com/LeoDavii"
            target="_blank"
            rel="noopener noreferrer"
            style={{ textDecoration: 'none', color: 'inherit' }}
            >
            <FaGithub />
            </a>          
            <a
            href="https://github.com/LeoDavii/ProjetoIntegrador/tree/main/Demonstra%C3%A7%C3%A3o%20de%20Usos%20e%20Testes%20Manuais"
            target="_blank"
            rel="noopener noreferrer"
            style={{ textDecoration: 'none', color: 'inherit' }}
            >
            <FaVideo />
            </a>     
            </div>
        </div>
        <div className="footer-section legal">
            <p>© 2024 Tiny Little Cakes - Projeto Integrador Transdisciplinar</p>
            <p>Cruzeiro do Sul Virtual | Leonardo Davi Tavares</p>
        </div>
    </footer>
);

export default Footer;
