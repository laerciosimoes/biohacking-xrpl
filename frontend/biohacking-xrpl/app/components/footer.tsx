import Link from 'next/link';

export default function Footer() {
  return (
    <footer className="footer bg-neutral text-neutral-content p-10">
      <nav>
        <h6 className="footer-title">Services</h6>
        <Link href="/branding" className="link link-hover">Branding</Link>
        <Link href="/design" className="link link-hover">Design</Link>
        <Link href="/marketing" className="link link-hover">Marketing</Link>
        <Link href="/advertisement" className="link link-hover">Advertisement</Link>
      </nav>
      <nav>
        <h6 className="footer-title">Company</h6>
        <Link href="/about" className="link link-hover">About us</Link>
        <Link href="/contact" className="link link-hover">Contact</Link>
        <Link href="/jobs" className="link link-hover">Jobs</Link>
        <Link href="/presskit" className="link link-hover">Press kit</Link>
      </nav>
      <nav>
        <h6 className="footer-title">Legal</h6>
        <Link href="/terms" className="link link-hover">Terms of use</Link>
        <Link href="/privacy" className="link link-hover">Privacy policy</Link>
        <Link href="/cookies" className="link link-hover">Cookie policy</Link>
      </nav>
    </footer>
  );
}
