import React from 'react';
import { render, screen } from '@testing-library/react';
import Contact from '../../components/Contact';

describe('Contact Component', () => {
    test('should render the contact section', () => {
      render(<Contact />);
      
      const contactTitle = screen.getByText(/contato/i);
      expect(contactTitle).toBeInTheDocument();
      
      const emailLink = screen.getByText(/l.davi.t@outlook.com/i);
      expect(emailLink).toBeInTheDocument();
    });
  
    test('should render the correct email address', () => {
      render(<Contact />);
      const emailLink = screen.getByText(/l.davi.t@outlook.com/i);
      expect(emailLink).toBeInTheDocument();
      expect(emailLink).toHaveAttribute('href', 'mailto:l.davi.t@outlook.com');
    });
  });