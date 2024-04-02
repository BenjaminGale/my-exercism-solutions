(defpackage :bob
  (:use :cl)
  (:export :response))
(in-package :bob)

(defun response (phrase)
  (let ((is-question (is-question-p phrase))
       (is-shouting (is-shouting-p phrase))
       (is-silent (is-silent-p phrase)))
       (cond ((and is-shouting is-question) "Calm down, I know what I'm doing!")
             (is-shouting "Whoa, chill out!")
             (is-question "Sure.")
             (is-silent "Fine. Be that way!")
             (t "Whatever."))))

(defun is-question-p (phrase)
  (let ((trimmed (string-trim '(#\Space) phrase)))
       (unless (zerop (length trimmed))
         (char= #\? (char (reverse trimmed) 0)))))

(defun is-shouting-p (phrase)
  (and
   (some #'alpha-char-p phrase)
   (every #'upper-case-p (remove-if-not #'alpha-char-p phrase))))

(defun is-silent-p (phrase)
  (or
   (zerop (length phrase))
   (every #'whitespace-char-p phrase)))

(defun whitespace-char-p (char)
  (member char '(#\Space #\Tab #\Newline #\Return)))
