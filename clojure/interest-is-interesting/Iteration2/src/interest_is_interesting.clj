(ns interest-is-interesting)

(defn interest-rate
  [balance]
  (cond (< balance 0)    -3.213
        (< balance 1000)  0.5
        (< balance 5000)  1.621
        :else             2.475
    )
  )

(defn annual-balance-update
  [balance]
  (+ balance (* (/ balance 100) (bigdec (Math/abs (interest-rate balance)))))
  )

(defn charity-multiplier
  [balance]
  (cond (<= balance 0) 0
        (>  balance 0) 2
        :else          1
    )
  )

(defn amount-to-donate
  [balance tax-free-percentage]
  (int (* (* (/ balance 100) tax-free-percentage) (charity-multiplier balance)))
  )