import React from 'react';
import { render, screen } from '@testing-library/react';
import Footer from '../../components/Footer';

test('Given Footer component when rendered then it displays correct content', () => {
    render(<Footer />);

    expect(screen.getByText('Cupcake Store')).toBeInTheDocument();
    expect(screen.getByText('Sobre Nós')).toBeInTheDocument();
    expect(screen.getByText('Fale Conosco')).toBeInTheDocument();
    expect(screen.getByText('Social')).toBeInTheDocument();
    expect(screen.getByText('© 2024 Cupcake Store - Projeto Integrador Transdisciplinar')).toBeInTheDocument();
    expect(screen.getByText('Cruzeiro do Sul Virtual | Leonardo Davi Tavares')).toBeInTheDocument();

    expect(screen.getByText(/Sobre Nós/)).toHaveAttribute('href', 'about');
    expect(screen.getByText(/Fale Conosco/)).toHaveAttribute('href', 'contact');
});