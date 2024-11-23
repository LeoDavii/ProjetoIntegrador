import React from 'react';
import './styles/About.css';

const About = () => {
  return (
    <section className="about">
      <h2 id="about-title" className="about-title">Sobre Nós</h2>
      <div className="about-content">
        <p>
          Bem-vindo à Cupcake Store! Somos uma empresa dedicada a trazer os melhores cupcakes
          artesanais para você. Com uma variedade de sabores e ingredientes de qualidade, nossa missão
          é proporcionar momentos doces e deliciosos.
        </p>
        <p>
          Fundada em 2024, nossa loja tem como objetivo oferecer um atendimento excepcional e
          produtos frescos para nossos clientes. Agradecemos por fazer parte da nossa jornada!
        </p>
      </div>
    </section>
  );
};

export default About;
