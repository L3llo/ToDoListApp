interface ProgressBarProps {
    label?: string;
    compact?: boolean;
}

function ProgressBar({ label, compact }: ProgressBarProps) {
    return (
        <div className={`progress-bar${compact ? ' progress-bar--compact' : ''}`} role="status" aria-live="polite">
            <div className="progress-bar__track">
                <div className="progress-bar__indicator" />
            </div>
            {label && <p className="progress-bar__label">{label}</p>}
        </div>
    );
}

export { ProgressBar };