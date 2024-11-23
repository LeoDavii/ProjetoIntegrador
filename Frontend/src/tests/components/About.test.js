import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom';
import About from '../../components/About';

describe('About Component', () => {
  test('renders the title "Sobre Nós"', () => {
    render(<About />);
    const titleElement = screen.getByText('Sobre Nós');
    expect(titleElement).toBeInTheDocument();
    expect(titleElement.tagName).toBe('H2');
    expect(titleElement).toHaveClass('about-title');
  });

  test('renders the welcome paragraph', () => {
    render(<About />);
    const welcomeParagraph = screen.getByText(/Bem-vindo à Cupcake Store!/i);
    expect(welcomeParagraph).toBeInTheDocument();
  });

  test('renders the foundation year paragraph', () => {
    render(<About />);
    const foundationParagraph = screen.getByText(/Fundada em 2024/i);
    expect(foundationParagraph).toBeInTheDocument();
  });

  test('renders two paragraphs in the content', () => {
    render(<About />);
    const paragraphs = screen.getAllByText((_, element) => element.tagName === 'P');
    expect(paragraphs).toHaveLength(2);
  });
});

