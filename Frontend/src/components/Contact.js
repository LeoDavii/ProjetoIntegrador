import React from 'react';
import './styles/Contact.css';

const Contact = () => {
  return (
    <section className="contact">
      <h2 className="contact-title">Contato</h2>
      <p>
        Envie um email para <strong>Leonardo Davi Tavares</strong>:{' '}
        <a href="mailto:l.davi.t@outlook.com">l.davi.t@outlook.com</a>
      </p>
    </section>
  );
};

export default Contact;
