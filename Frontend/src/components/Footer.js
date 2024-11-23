import React from 'react';
import { FaGithub, FaGoogle, FaLinkedin } from 'react-icons/fa';
import './styles/Footer.css';

const Footer = () => (
    <footer className="footer">
        <div className="footer-section">
            <h4>Cupcake Store</h4>
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
                style={{ textDecoration: 'none', color: 'inherit' }} // opcional, estilização do link
                >
                <FaLinkedin />
            </a>  
            <a
            href="https://github.com/LeoDavii"
            target="_blank"
            rel="noopener noreferrer"
            style={{ textDecoration: 'none', color: 'inherit' }} // opcional, estilização do link
            >
            <FaGithub /> {/* Tamanho ajustável */}
            </a>          
            <a
            href="https://github.com/LeoDavii"
            target="_blank"
            rel="noopener noreferrer"
            style={{ textDecoration: 'none', color: 'inherit' }} // opcional, estilização do link
            >
            <FaGoogle /> {/* Tamanho ajustável */}
            </a>     
            </div>
        </div>
        <div className="footer-section legal">
            <p>© 2024 Cupcake Store - Projeto Integrador Transdisciplinar</p>
            <p>Cruzeiro do Sul Virtual | Leonardo Davi Tavares</p>
        </div>
    </footer>
);

export default Footer;
