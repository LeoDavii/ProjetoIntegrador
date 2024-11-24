import React from 'react';
import './styles/About.css';

const About = () => {
  return (
    <section className="about">
      <h2 id="about-title" className="about-title">Sobre Nós</h2>
      <div className="about-content">
        <p>
          Bem-vindo à Tiny Little Cakes! Parte do projeto integrador interdisciplinar de Leonardo Davi Tavares. 
          Desenvolvido no segundo semestre de 2024, a ideia é trazer um mockup de um commerce de cupcakes.
          Explore à vontade!
        </p>
      </div>
    </section>
  );
};

export default About;
